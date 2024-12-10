import logging
from logging import Logger
import datetime
logging.basicConfig(level=logging.INFO, filename=f"logs/{datetime.date.today()}.log",filemode="w",
                    format="%(asctime)s %(levelname)s %(message)s")

logger = logging.getLogger(__name__)


def log_info_with_separator(message: str) -> None:
    logger.info("=" * 5)
    logger.info(message)
    logger.info("=" * 5)